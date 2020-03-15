angular.module("app", ["chart.js"]).

    controller("ChartCtrl", function ($scope,dataRepo) {

        $scope.labels = [];
        $scope.series = ['Totale Positivi', 'Dececuti'];
        $scope.data = [
            [],
            []
        ];
        $scope.onClick = function (points, evt) {
            console.log(points, evt);
        };
        $scope.datasetOverride = [{ yAxisID: 'y-axis-1' }, { yAxisID: 'y-axis-2' }];
        $scope.options = {
            scales: {
                yAxes: [
                    {
                        id: 'y-axis-1',
                        type: 'linear',
                        display: true,
                        position: 'left'
                    },
                    {
                        id: 'y-axis-2',
                        type: 'linear',
                        display: true,
                        position: 'right'
                    }
                ]
            }
        };

        $scope.myFunct = function (keyEvent) {
            if (keyEvent.which === 13)
                loadData($scope.regione);
        };


        function loadData(regione) {
            dataRepo.getPositivi(regione).then(function (data) {
                $scope.data[0] = data.data;
            });
            dataRepo.getDeceduti(regione).then(function (data) {
                $scope.data[1] = data.data;
            });
            dataRepo.getDate(regione).then(function (data) {
                $scope.labels = data.data;
            });

        }
        loadData("Emilia");
    });