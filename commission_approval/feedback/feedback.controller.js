(function () {
    'use strict';

    angular
        .module('app')
        .controller('FeedbackController', FeedbackController);

        FeedbackController.$inject = ['$rootScope', '$scope', '$http', '$routeParams'];
        function FeedbackController($rootScope, $scope, $http, $routeParams) {
            $http.get('/api/commission?id='+$routeParams.id).then(function(response) {
                response = response.data
                $scope.marketing_firstname = response.marketing_firstname
                $scope.marketing_lastname = response.marketing_lastname
                $scope.marketing_id = response.marketing_id
                $scope.marketing_team = response.marketing_team

                $scope.customer_firstname = response.customer_firstname
                $scope.customer_lastname = response.customer_lastname
                $scope.customer_bank_id = response.customer_bank_id
                $scope.customer_id = response.customer_id

                $scope.percent_option_1 = response.percent_option_1
                $scope.percent_option_2 = response.percent_option_2
                $scope.percent_option_3 = response.percent_option_3
                $scope.percent_option_4 = response.percent_option_4

                $scope.note_text = response.note_text
                $scope.note_file = response.note_file

                $scope.boss_1_comment = response.boss_1_comment
                $scope.boss_2_comment = response.boss_2_comment

                $scope.percent_option_1_first_comment = response.percent_option_1_first_comment == 'true'
                $scope.percent_option_2_first_comment = response.percent_option_2_first_comment == 'true'
                $scope.percent_option_3_first_comment = response.percent_option_3_first_comment == 'true'
                $scope.percent_option_4_first_comment = response.percent_option_4_first_comment == 'true'

                $scope.percent_option_1_second_comment = response.percent_option_1_second_comment == 'true'
                $scope.percent_option_2_second_comment = response.percent_option_2_second_comment == 'true'
                $scope.percent_option_3_second_comment = response.percent_option_3_second_comment == 'true'
                $scope.percent_option_4_second_comment = response.percent_option_4_second_comment == 'true'
          })
        }

})();
