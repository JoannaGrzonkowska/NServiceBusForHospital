var ExaminationType = {
    BLOOD : 1,
    RTG : 2,
    USG : 3,
    LAB: 4
};

function getExaminationTypeName(view) {

    switch (view) {
        case 1:
            return 'Blood';
        case 2:
            return 'RTG';
        case 3:
            return 'USG';
        case 4:
            return 'Lab';
    }
};

var LogType = {
    Request: 1,
    Response: 2
};

function getLogTypeName(view) {

    switch (view) {
        case 1:
            return 'Request';
        case 2:
            return 'Response';
      }
};
