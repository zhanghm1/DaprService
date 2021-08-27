<template>
  <div>
    
  </div>
</template>

<script >
import  staffService  from '../services/staffService'
export default {
  name: 'Header',
  async created(){
    let current = await staffService.getStaffInfo();
  }
}
</script>

<style>

</style>
