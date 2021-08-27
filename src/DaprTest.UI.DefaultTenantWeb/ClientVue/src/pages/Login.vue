<template>
  <div> 
    <div class="loginform">
      <el-button type="primary"  @click="login">登录</el-button>
    </div>

  </div>
</template>

<script >
import oidcUserManager from '../common/oidc'
export default {
  name: 'Login',
  methods:{
    login(){
      oidcUserManager.signinRedirect();
    },
  },
  created(){
    oidcUserManager.getUser().then((user)=> {
        if (user) {
            console.log("Login User:",user);
            this.$router.push("/index");
        }else {
            console.log("需要登陆");
        }
    });
  }
  
}
</script>

<style>

</style>
