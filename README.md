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
		Tenant				商户自管理服务，已默认添加员工账号
		DefaultTenantWeb	默认的一个产品展示前台
	
	
	
