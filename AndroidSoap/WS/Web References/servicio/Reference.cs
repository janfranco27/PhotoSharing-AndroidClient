//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WS.servicio {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WSSoap11Binding", Namespace="http://WS.PhotoSharing.unsa.com")]
    public partial class WS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public WS() {
            this.Url = "http://192.168.1.34:8080/PhotoSharing/services/WS.WSHttpSoap11Endpoint/";
        }
        
        public WS(string url) {
            this.Url = url;
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:servicio", RequestNamespace="http://WS.PhotoSharing.unsa.com", ResponseNamespace="http://WS.PhotoSharing.unsa.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable=true)]
        public string[] servicio([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string tag) {
            object[] results = this.Invoke("servicio", new object[] {
                        tag});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult Beginservicio(string tag, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("servicio", new object[] {
                        tag}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] Endservicio(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
    }
}
