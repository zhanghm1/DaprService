<template>
  <router-view></router-view>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Menu from './components/Menu.vue'

export default defineComponent({
  name: 'App',
  components: {
    Menu
  }
})
</script>

<style>
*{
  margin: 0;
  padding: 0;
}
html,body{
  height: 100%;
}
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  height: 100%;
}

</style>
