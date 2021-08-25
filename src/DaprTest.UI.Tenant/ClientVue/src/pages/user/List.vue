<template>
  <div> User List</div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import  staffService  from '../../services/staff/staffService'
export default defineComponent({
  name: 'UserList',
  created(){
    staffService.getStaffList({}).then(a=>{
      console.log(a);
    });

  }
})
</script>

<style>

</style>
