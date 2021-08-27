import  {createRouter,createWebHashHistory}  from 'vue-router'
// 定义一组路由
const routes = [
    
    { path: '/', component: () => import('../pages/Login.vue') },
    { path: '/login', component: () => import('../pages/Login.vue') },
    { path: '/logincallback', component: () => import('../pages/LoginCallback.vue') },
    { path: '/', component: () => import('../pages/Home.vue'),
      children:[
        { path: '/index', component: () => import('../pages/Index.vue') },
        { path: '/staff/list', component: () => import('../pages/staff/List.vue') },
      ]
    },
  ]
  
  //创建路由实例并传递 `routes` 配置
  //你可以在这里输入更多的配置，但我们在这里
  const router = createRouter({
    //内部提供了 history 模式的实现。为了简单起见，我们在这里使用 hash 模式。
    history: createWebHashHistory(),
    routes,
  })

  export default router;