const baseUrl="http://localhost:5124/api/TrashCans"
Vue.createApp({
    data(){
        return {
            name:null,
            msg:null,
            newAddress:null,
            allTrash:[],
            idToUpdate:null,
            idToDelete:null,
            trashCan:null,
            trashCanId:null,
            updateData:{id:0, city:"",address:"",zipCode:"",isFull:true,estimate:0,lastEmptied:"2022-11-30t11:47:12.1822668+01:00"},
            addData:{id:0,city:"",address:"",zipCode:4919,isFull:true,Estimate:0,lastEmptied:"2022-11-30T11:47:12.1822668+01:00"}
        }
    },
    async created(){
        this.GetAll(baseUrl)
    },
    methods:{
        async GetAll(url){
            try{
                const response =await axios.get(url)
                this.allTrash = await response.data
                console.log(this.allTrash)
            } catch(ex){
                alert(ex.message)
            }
        },
        async addTrash(){
            try{
                const response = await axios.post(baseUrl,this.addData)
                this.trashCan = await response.data
                this.GetAll(baseUrl)
                console.log(this.allTrash)
            } catch(ex){
                alert(ex.message)
            }
            
        },
        async removeTrash(idToDelete){
            const url=baseUrl + "/" + idToDelete
            try{
                response = await axios.delete(url)
                this.msg = "Removed the trashcan!"
                this.GetAll(baseUrl)
            } catch(ex){
                alert(ex.message)
            }
        },
        async showTrash(id){
            const url=baseUrl + "/"+ id
            try{
                const response = await axios.get(url)
                this.trashCan=await response.data
            } catch(ex){
                alert(ex.message)
            }
        },
        sortByID(){
            this.GetAll(baseUrl + "?sort_by=id")
        },
        sortByCity(){
            this.GetAll(baseUrl + "?sort_by=city")
        },
        sortByisFull(){
            this.GetAll(baseUrl + "?sort_by=isFull")
        },
        sortByLastEmptied(){
            this.GetAll(baseUrl + "?sort_by=LastEmptied")
        }

    }
}).mount("#app")