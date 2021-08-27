<template>
  <div> User List</div>
</template>

<script >
import  storeService  from '../../services/storeService'
export default {
  name: 'UserList',
  created(){
    storeService.getList({}).then(a=>{
      console.log(a);
    });

  }
}
</script>

<style>

</style>
