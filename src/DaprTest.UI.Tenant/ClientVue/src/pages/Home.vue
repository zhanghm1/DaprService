<template>
  <el-container  class="container-body">
    <el-header>
      <Header></Header>
    </el-header>
    <el-container class="container-main">
      <el-aside width="180px"><Menu></Menu></el-aside>
      <el-main>
        <router-view></router-view>
      </el-main>
    </el-container>
  </el-container>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Menu from '../components/Menu.vue'
import Header from '../components/Header.vue'

export default defineComponent({
  name: 'App',
  components: {
    Menu,
    Header
  }
})
</script>

<style scoped>
.el-header, .el-footer {
    background-color: #B3C0D1;
    color: #333;
    text-align: center;
    line-height: 60px;
  }
.container-body{
    height: 100%;
}
.container-main{
  height: 100%;
}
  .el-aside {
    background-color: #545c64;
    color: #333;
    text-align: center;
    line-height: 200px;
  }

  .el-main {
    background-color: #E9EEF3;
    color: #333;
    text-align: center;
    line-height: 160px;
  }

  body > .el-container {
    margin-bottom: 40px;
  }
</style>
