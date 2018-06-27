var myApp = angular.module('ca-cuoc', ['ngMessages','ngResource']);

myApp.controller('mainController', [
    '$scope', '$filter', '$http', function($scope, $filter, $http,$resource) {
        $scope.TenTaiKhoan = '';
        $scope.MatKhau = '';

        $scope.Login = function() {
            var $btn = $('#btnDangky');
            $btn.button('loading');

            var Data = {
                TenTaiKhoan: $scope.TenTaiKhoan,
                MatKhau: $scope.MatKhau,
                Checked: true
            };

            $http({
                traditional: true,
                method: 'POST',
                url: '/Account/KiemTraDangNhap',
                data: JSON.stringify(Data),
                contentType: "application/json",
                dataType: "json"
            }).then(function successCallback(response) {
                if (response.data.code == 1) {
                    $(location).attr('href', '/');
                } else if(response.data.code==0){
                    toastr['error']('Chưa cống nạp tiền mà đòi vô ah!');
                }else if (response.data.code == 2) {
                    toastr['error']('Rất tiếc tài khoản không tồn tại nhé !');
                }
                //$('#btnDangNhap').prop('disabled', false);
                $btn.button('reset');
            }).then(function errorCallback(response) {
                toastr["error"](response.data);
                $('#btnDangNhap').prop('disabled', false);
                $btn.button('reset');
            });
        };
    }
]);

myApp.controller('registerController', [
    '$scope', '$filter', '$http', function($scope, $filter, $http) {
        $scope.TenTaiKhoan = '';
        $scope.HoVaTen = '';
        $scope.Email = '';
        $scope.MatKhau = '';

        $scope.DangKy= function() {
            //$('#btnDangky').prop('disabled', true);
            var $btn = $('#btnDangky');
            $btn.button('loading');

            var format = /[ !@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/;

            if (format.test($scope.TenTaiKhoan)) {
                toastr["error"]("Tên tài khoản không hợp lệ");

                return;
            }
            
            var Data = {
                Email: $scope.Email,
                TenTaiKhoan: $scope.TenTaiKhoan,
                HoVaTen: $scope.HoVaTen,
                MatKhau: $scope.MatKhau
            };

            $http({
                traditional: true,
                method: 'POST',
                url: '/Account/DangKyTaiKhoan',
                data:JSON.stringify(Data),
                contentType: "application/json",
                dataType: "json"
            }).then(function successCallback(response) {
                    if (response.data !== "")
                        toastr["error"](response.data);
                    else {
                        toastr["success"](
                            'Bạn đã đăng ký thành công, vui lòng yêu cầu kích hoạt trước khi sử dụng! Chào thân ái và quyết thắng');

                        setTimeout(function() {
                                $(location).attr('href', '/dang-nhap');
                            },
                            5000);
                    }

                    $btn.button('reset');
                },
                function errorCallback(response) {
                    toastr["error"](response.data);
                    $btn.button('reset');
                });
        }
    }
]);