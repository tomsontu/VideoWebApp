var app = new Vue({
    el: "#app",
    data: {
        videos: [],
        pageSize: 8, // Number of videos per page
        currentPage: 1, // Current page number
    },

    mounted() {
        this.getVideos();
    },

    computed: {
        // Calculate total number of pages
        totalPages() {
            return Math.ceil(this.videos.length / this.pageSize);
        },

        // Slice videos to display only those for the current page
        displayedVideos() {
            const startIndex = (this.currentPage - 1) * this.pageSize;
            const endIndex = startIndex + this.pageSize;
            return this.videos.slice(startIndex, endIndex);
        }
    },


    methods: {
        getVideos() {
            this.loading = true;
            axios.get('/video/videos').then(res => {
                console.log(res.data);
                this.videos = res.data;

            })
                .catch(error => {
                    console.log(error);
                })
                .then(() => {
                    this.loading = false;
                });
        },

        nextPage() {
            if (this.currentPage < this.totalPages) {
                this.currentPage++;
            }
        },

        previousPage() {
            if (this.currentPage > 1) {
                this.currentPage--;
            }
        },
        firstPage() {
            this.currentPage = 1;
        },

        lastPage() {
            this.currentPage = this.totalPages;
        },
    },
});