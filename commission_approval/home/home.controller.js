(function () {
    'use strict';

    angular
        .module('app')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['$rootScope', '$scope', '$http', 'Upload'];
    function HomeController($rootScope, $scope, $http, Upload) {
        $scope.marketing_firstname = ''
        $scope.marketing_lastname = ''
        $scope.marketing_id = ''
        $scope.marketing_team = ''

        $scope.customer_firstname = ''
        $scope.customer_lastname = ''
        $scope.customer_bank_id = ''
        $scope.customer_id = ''

        $scope.percent_option_1 = ''
        $scope.percent_option_2 = ''
        $scope.percent_option_3 = ''
        $scope.percent_option_4 = ''

        $scope.note_text = ''
        $scope.note_file = ''

        var generate_id = function() {
            return 'id-' + Math.random().toString(36).substr(2, 16)
        }

        var get_type_file = function(filename) {
            var arr = filename.split('.')
            return arr[arr.length - 1]
        }
        $scope.on_click_success = function() {
          if (
            $scope.marketing_firstname &&
            $scope.marketing_lastname &&
            $scope.marketing_id &&
            $scope.marketing_team &&

            $scope.customer_firstname &&
            $scope.customer_lastname &&
            $scope.customer_bank_id &&
            $scope.customer_id
          ) {
              $scope.loading = true
            if($scope.note_file) {
              var formData = new FormData()
              formData.append('file', $scope.note_file)
              $scope.note_file = $scope.note_file.name

              // Upload.upload({
              //     url: '/api/upload',
              //     data: {file: $scope.note_file}
              // })

              fetch('/api/upload', {
                  method: 'POST',
                  body: formData
              })
              .then(function(response) {
                  return response.json()
              })
              .catch(function(error) {
                  console.error('Error:', error)
              })
              .then(function(response) {
                  console.log('Success:', response)
              })
            }
            $http.post('/api/commission', {
              id: generate_id(),
              marketing_firstname: $scope.marketing_firstname,
              marketing_lastname: $scope.marketing_lastname,
              marketing_id: $scope.marketing_id,
              marketing_team: $scope.marketing_team,

              customer_firstname: $scope.customer_firstname,
              customer_lastname: $scope.customer_lastname,
              customer_bank_id: $scope.customer_bank_id,
              customer_id: $scope.customer_id,

              percent_option_1: $scope.percent_option_1 || '-',
              percent_option_2: $scope.percent_option_2 || '-',
              percent_option_3: $scope.percent_option_3 || '-',
              percent_option_4: $scope.percent_option_4 || '-',

              note_text: $scope.note_text || '-',
              note_file: $scope.note_file || '-'
          }).then(function() {
                window.location.href = '/#/success'
            })
          }
        }
    }

})();
