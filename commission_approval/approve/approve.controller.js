(function () {
    'use strict';

    angular
        .module('app')
        .controller('ApproveController', ApproveController);

    ApproveController.$inject = ['$rootScope', '$scope', '$http', '$routeParams'];
    function ApproveController($rootScope, $scope, $http, $routeParams) {
        if ($routeParams.token == '56A3A95FE33D878A471DAF6BC9319' || $routeParams.token == '37F5BDACD55CAAD7751CDB6EEFA39') {
            $scope.user = $routeParams.token == '56A3A95FE33D878A471DAF6BC9319' ? 1 : 2
        } else {
            window.location.href = '/#/nopermission'
        }
        $scope.on_success = function() {
            $scope.loading = true

            var data = {
                id: $routeParams.id,
                marketing_firstname: $scope.marketing_firstname,
                marketing_lastname: $scope.marketing_lastname,
                marketing_id: $scope.marketing_id,
                marketing_team: $scope.marketing_team,

                customer_firstname: $scope.customer_firstname,
                customer_lastname: $scope.customer_lastname,
                customer_bank_id: $scope.customer_bank_id,
                customer_id: $scope.customer_id,

                percent_option_1: $scope.percent_option_1,
                percent_option_2: $scope.percent_option_2,
                percent_option_3: $scope.percent_option_3,
                percent_option_4: $scope.percent_option_4,

                note_text: $scope.note_text,
                note_file: $scope.note_file,

                percent_option_1_first_comment: $scope.percent_option_1_first_comment.toString(),
                percent_option_2_first_comment: $scope.percent_option_2_first_comment.toString(),
                percent_option_3_first_comment: $scope.percent_option_3_first_comment.toString(),
                percent_option_4_first_comment: $scope.percent_option_4_first_comment.toString(),
                boss_1_comment: $scope.boss_1_comment,

                percent_option_1_second_comment: $scope.percent_option_1_second_comment.toString(),
                percent_option_2_second_comment: $scope.percent_option_2_second_comment.toString(),
                percent_option_3_second_comment: $scope.percent_option_3_second_comment.toString(),
                percent_option_4_second_comment: $scope.percent_option_4_second_comment.toString(),
                boss_2_comment: $scope.boss_2_comment,
                
                boss_1_done: $scope.boss_1_done,
                boss_2_done: $scope.boss_2_done,
            }

            if($scope.user == 1) {
                data.boss_1_done = 'true'
            } else {
                data.boss_2_done = 'true'
            }

            $http.put('/api/commission/'+$routeParams.id, data).then(function() {
                window.location.href = '/#/success'
            })
        }

        $http.get('/api/commission/'+$routeParams.id).then(function(response) {
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

            $scope.boss_1_done = response.boss_1_done
            $scope.boss_2_done = response.boss_2_done
      })
    }

})();
