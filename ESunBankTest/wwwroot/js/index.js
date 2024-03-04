var app = new Vue({
    el: '#app',
    data: {
        dataList: [],
    },
    filters: {
        momentDate(value) {
            return moment(value).format("yyyy年MM月")
        },
        currency(value) {
            if (!value) return 0;
            const intPart = Math.trunc(value);
            const intPartFormat = intPart.toString().replace(/(\d)(?=(?:\d{3})+$)/g, '$1,');
            let floatPart = '';
            const valueArray = value.toString().split('.');
            if (valueArray.length === 2) {
                floatPart = valueArray[1].toString()
                return intPartFormat + '.' + floatPart;
            }
            return intPartFormat + floatPart;
        },
    },
    methods: {
        getDataFromAPI() {
            var vm = this;
            axios.post('/api/Labor/GetData13223ToDataBase')
                .then(function (response) {
                    if (response.data) {
                        alert(`${response.data.Message}`);
                        if (response.data.Success) {
                            vm.getDataFromDataBase();
                        }
                    } else {
                        alert("執行失敗");
                    }
                })
                .catch(function (error) {
                    alert(`執行失敗:/n${JSON.stringify(error)}`);
                });
        },

        getDataFromDataBase() {
            var vm = this;
            axios.get('/api/Labor/GetData13223FromDataBase')
                .then(function (response) {
                    if (response.data) {
                        if (response.data.Success) {
                            vm.dataList = response.data.Data[0];
                        }
                    } else {
                        alert("執行失敗");
                    }
                })
                .catch(function (error) {
                    alert(`執行失敗:/n${JSON.stringify(error)}`);
                });
        }
    },
    mounted() {
        var vm = this;
        vm.getDataFromAPI();
    }
})