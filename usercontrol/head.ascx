<%@ Control Language="C#" AutoEventWireup="true" CodeFile="head.ascx.cs" Inherits="usercontrol_head" %>
<div id="head">
        <table width="980px" height="105px" border="0" cellspacing="0" cellpadding="0" align="center">
            <tr>
                <td align="center" valign="bottom" style="background-image:url(/images/yesgama.png)"><table width="467" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="253" align="right" style="font-size:16px; font-weight:bolder; color:#FFF; font:'幼圆';" height="30px"><a href="/index.html" target="_self" title="首页">首页</a></td>
                    <td width="72" align="right" style="font-size:16px; font-weight:bolder; color:#FFF; font:'幼圆';"><a href="/about.html" target="_blank" title="关于本站">关于本站</a></td>
                    <td width="76" align="center" style="font-size:16px; font-weight:bolder; color:#FFF; font:'幼圆';"><a href="#" onclick="SetHome(this,window.location)" title="设为首页">设为首页</a></td>
                    <td width="66" style="font-size:16px; font-weight:bolder; color:#FFF; font:'幼圆';"><img src="/images/rss.png" width="16" height="16" /><a href="/rss.html" target="_blank" title="订阅RSS">RSS</a></td>
                  </tr>
                </table></td>
            </tr>
        </table>
    </div>
    <div style="height:1px"></div>
    <SCRIPT LANGUAGE="JavaScript">


function SetHome(obj,vrl){
        try{
                obj.style.behavior='url(#default#homepage)';obj.setHomePage(vrl);
        }
        catch(e){
                if(window.netscape) {
                        try {
                                netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
                        }
                        catch (e) {
                                alert("此操作被浏览器拒绝！\n请在浏览器地址栏输入“about:config”并回车\n然后将 [signed.applets.codebase_principal_support]的值设置为'true',双击即可。");
                        }
                        var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
                        prefs.setCharPref('browser.startup.homepage',vrl);
                 }
        }
}
</SCRIPT>