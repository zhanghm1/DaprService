<template>
  <div> Staff List</div>
</template>

<script >
import  staffService  from '../../services/staffService'
export default {
  name: 'StaffList',
  created(){
    staffService.getList({}).then(a=>{
      console.log(a);
    });

  }
}
</script>

<style>

</style>
