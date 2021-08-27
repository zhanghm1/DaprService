# DaprService
	项目目录结构
	framework 相关的类库项目
		Applicaion 业务服务
		Domain 实体
		EFCore EF 的DbContext
		Common 辅助的功能
	gateway  
		nginxgateway   nginx 反向代理做网关
	services
		MemberApi   		会员服务API
		OrderApi    		订单服务API
		PayAI				支付服务API
		ProductAPI			商品服务API
		TenantAPI			商户服务API

	web
		IdentityServer      统一登录服务
		Admin				商户注册服务，已默认添加管理员账号，添加商户，客户端
		Tenant				商户自管理服务，已默认添加员工账号 vue 项目
		DefaultTenantWeb	默认的一个产品展示前台		vue 项目
	
	
	运行指南
	安装vs 2019,  .net 5
	安装docker desktop
	安装dapr
	
	修改src 目录下的.env 文件的IP改为自己本机IP
	修改前端项目 ClientVue/public/config/config.js 下面的IP改为自己本机IP
	
	
	
	
