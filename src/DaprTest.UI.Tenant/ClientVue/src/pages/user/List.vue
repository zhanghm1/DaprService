<template>
  <div> User List</div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import  staffService  from '../../services/staffService'
export default defineComponent({
  name: 'UserList',
  created(){
    staffService.getStaffList();

  }
})
</script>

<style>

</style>
