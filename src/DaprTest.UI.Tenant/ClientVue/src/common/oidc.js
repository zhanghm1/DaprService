import Oidc from 'oidc-client'

var oidcUserManager = new Oidc.UserManager(window.oidc_config);

export default  oidcUserManager;