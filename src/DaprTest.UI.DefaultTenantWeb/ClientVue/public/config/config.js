var LOCALHOST_IP = "192.168.1.238";
var oidc_config = {
    authority: "http://" + LOCALHOST_IP+":7000",
    client_id: "DefaultTenantWeb",
    redirect_uri: "http://" + LOCALHOST_IP +":7003/#/logincallback",
    response_type: "code",
    scope:"openid profile orderapi productapi memberapi",
    post_logout_redirect_uri: "http://" + LOCALHOST_IP +":7003/#/login",
};

window.oidc_config=oidc_config;
window.apiurl="http://"+LOCALHOST_IP+":6001";