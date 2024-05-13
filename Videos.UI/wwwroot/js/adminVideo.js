var app = new Vue({
    el: "#app",
    data: {
        videos: [],
        pageSize: 7, // Number of videos per page
        currentPage: 1, // Current page number
        displayedVideos: [],
        totalPages: 0,
        editing: false,

    },

    mounted() {
        this.getVideos();
    },

    computed: {

    },

    watch: {
        videos: {
            handler() {
                this.updatePagination();
            },
            deep: true
        },
        currentPage() {
            this.updatePagination();
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

        deleteVideo(videoId, index) {
            
            this.loading = true;
            axios.delete('/video/videos/' + videoId).then(res => {
                console.log(res.data);
                this.videos.splice(index + (this.currentPage - 1) * this.pageSize, 1);

            })
                .catch(error => {
                    console.log(error);
                })
                .then(() => {
                    this.loading = false;
                });
        },

        addRemark(videoId, index) {
            this.editing = true;
            this.loading = true;
            axios.put('/video/videos/', { remark: this.videos[index + (this.currentPage - 1) * this.pageSize].remark, videoId: videoId }).then(res => {
                console.log(res.data);
                //this.videos.splice(index + (this.currentPage - 1) * this.pageSize, 1, res.data);
                alert("Done!");
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

        updatePagination() {
            this.totalPages = Math.ceil(this.videos.length / this.pageSize);
            // Ensure currentPage is within range
            this.currentPage = Math.min(this.currentPage, this.totalPages);
            // Recalculate displayedVideos based on the currentPage
            const startIndex = (this.currentPage - 1) * this.pageSize;
            const endIndex = startIndex + this.pageSize;
            this.displayedVideos = this.videos.slice(startIndex, endIndex);
        },
    },
});