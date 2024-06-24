var app = new Vue({
    el: "#app",
    data: {
        videos: [],
        videosCopy: [],
        pageSize: 8, // Number of videos per page
        currentPage: 1, // Current page number
        searchQuery: '',
        searchResults: [],
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
        async search() {
            this.currentPage = 1;
            this.videos = this.videosCopy;
            try {
                const response = await axios.post('http://localhost:9200/videos/_search', {
                    query: {
                        match: {
                            description: this.searchQuery
                        }
                    }
                });

                this.searchResults = response.data.hits.hits;

                const videoIdSet = new Set();

                this.searchResults.forEach(hit => {
                    if (hit._source && hit._source.videoId) {
                        videoIdSet.add(hit._source.videoId);
                    }
                });

                console.log(videoIdSet);

                const filteredVideos = this.videos.filter(video => videoIdSet.has(video.videoId));
                this.videos = filteredVideos;

                console.log(filteredVideos);

            } catch (error) {
                console.error('Error searching:', error);
            }
        
        },

        async reset() {
            this.currentPage = 1;
            this.videos = this.videosCopy;
        },

        getVideos() {
            this.loading = true;
            axios.get('/video/videos').then(res => {
                console.log(res.data);
                this.videos = res.data;
                this.videosCopy = res.data;
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