var app = new Vue({
    el: '#app',
    data: {
        username: "",
        password: "",
    },
    mounted() {
        
    },
    methods: {
        createUser() {
            this.loading = true;
            axios.post('/users', { username: this.username,  password: this.password}).then(res => {
                console.log(res.data);
                this.products = res.data;

            })
                .catch(error => {
                    console.log(error);
                })
                .then(() => {
                    this.loading = false;
                });
        },
    }
})