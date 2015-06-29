﻿using log4net;
using RepositoryClasses;
using System;
using System.Data.Common;
using System.Data.Entity.Validation;
using System.Text;

namespace WardDataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UnitOfWork));

        private KSR_WardEntities _dataContext;

        public UnitOfWork(KSR_WardEntities dataContext)
        {
            _dataContext = dataContext;
        }

        public void SaveChanges()
        {
            try
            {
                _dataContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var dbValidationException = e;

                var stringBuilder = new StringBuilder();

                foreach (var eve in dbValidationException.EntityValidationErrors)
                {
                    stringBuilder.AppendFormat("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        stringBuilder.AppendFormat("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                Log.Error(stringBuilder.ToString(), e);
                throw;
            }
            catch (DbException e)
            {
                Log.Error("Cannot save changes.", e);
                throw;
            }
        }


        public void Dispose()
        {
            try
            {
                if (_dataContext != null)
                {
                    _dataContext.Dispose();
                    _dataContext = null;
                }
            }
            catch (Exception)
            {
                // Dispose should be called without throwing any exceptions.
            }
        }
    }
}
