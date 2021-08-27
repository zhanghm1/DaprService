<template>
  <div></div>
</template>

<script>
import Oidc from 'oidc-client'

export default {
  name: 'LoginCallback',
  created(){
    new Oidc.UserManager({ response_mode: "query" }).signinRedirectCallback().then((userInfo)=>{
      console.log("LoginCallbackUserInfo",userInfo);
      localStorage.setItem("access_token",userInfo.access_token);
      localStorage.setItem("expires_at",userInfo.expires_at);
      localStorage.setItem("scope",userInfo.scope);
      localStorage.setItem("token_type",userInfo.token_type);
      this.$router.push("/index");
    }).catch(function (e) {
        console.error(e);
    });
  }
}
</script>

<style>

</style>
