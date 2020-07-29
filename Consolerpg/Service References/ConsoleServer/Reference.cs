﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Consolerpg.ConsoleServer {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="ConsoleServer.ConsoleServer")]
    public interface ConsoleServer {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:ConsoleServer/LoginUser", ReplyAction="urn:ConsoleServer/LoginUserResponse")]
        int LoginUser(string username, string senha);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:ConsoleServer/getUserData", ReplyAction="urn:ConsoleServer/getUserDataResponse")]
        string[] getUserData(int idPersonagem);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:ConsoleServer/getAreaData", ReplyAction="urn:ConsoleServer/getAreaDataResponse")]
        string[] getAreaData(int idArea);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:ConsoleServer/testar", ReplyAction="urn:ConsoleServer/testarResponse")]
        string testar(string envio);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ConsoleServerChannel : Consolerpg.ConsoleServer.ConsoleServer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ConsoleServerClient : System.ServiceModel.ClientBase<Consolerpg.ConsoleServer.ConsoleServer>, Consolerpg.ConsoleServer.ConsoleServer {
        
        public ConsoleServerClient() {
        }
        
        public ConsoleServerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ConsoleServerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConsoleServerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConsoleServerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int LoginUser(string username, string senha) {
            return base.Channel.LoginUser(username, senha);
        }
        
        public string[] getUserData(int idPersonagem) {
            return base.Channel.getUserData(idPersonagem);
        }
        
        public string[] getAreaData(int idArea) {
            return base.Channel.getAreaData(idArea);
        }
        
        public string testar(string envio) {
            return base.Channel.testar(envio);
        }
    }
}