//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option or rebuild the Visual Studio project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "12.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Localizations {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Localizations() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.Localizations", global::System.Reflection.Assembly.Load("App_GlobalResources"));
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Submit.
        /// </summary>
        internal static string AddAlergyToPatient {
            get {
                return ResourceManager.GetString("AddAlergyToPatient", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Inform about new patient&apos;s diesease.
        /// </summary>
        internal static string AddNewDiesease {
            get {
                return ResourceManager.GetString("AddNewDiesease", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Choose2.
        /// </summary>
        internal static string ChooseAlergyType_Placeholder {
            get {
                return ResourceManager.GetString("ChooseAlergyType_Placeholder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Choose.
        /// </summary>
        internal static string ChooseDieseaseType_Label {
            get {
                return ResourceManager.GetString("ChooseDieseaseType_Label", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Description.
        /// </summary>
        internal static string DescriptionHeader {
            get {
                return ResourceManager.GetString("DescriptionHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Diesease.
        /// </summary>
        internal static string DieseasesNameHeader {
            get {
                return ResourceManager.GetString("DieseasesNameHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Description.
        /// </summary>
        internal static string PatientDieseaseDescription_Label {
            get {
                return ResourceManager.GetString("PatientDieseaseDescription_Label", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please add new description.
        /// </summary>
        internal static string PatientDieseaseDescription_Placeholder {
            get {
                return ResourceManager.GetString("PatientDieseaseDescription_Placeholder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Send Message.
        /// </summary>
        internal static string SendMessage {
            get {
                return ResourceManager.GetString("SendMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Diagnosed:.
        /// </summary>
        internal static string WhenDiagnosedHeader {
            get {
                return ResourceManager.GetString("WhenDiagnosedHeader", resourceCulture);
            }
        }
    }
}
