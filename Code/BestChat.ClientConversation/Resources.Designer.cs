﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BestChat.ClientConversation {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BestChat.ClientConversation.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This view shows any events that don&apos;t belong to any other view..
        /// </summary>
        internal static string strClientConversationViewDesc {
            get {
                return ResourceManager.GetString("strClientConversationViewDesc", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Client.
        /// </summary>
        internal static string strClientConversationViewName {
            get {
                return ResourceManager.GetString("strClientConversationViewName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Help is available from many places:\r\n\t-|/commands| lists all the built-in commands in Best Chat. Use |/help &lt;command-name&gt;| to get help on individual commands.\r\n\t-The IRC Help website http://www.irchelp.org/ provides introductory material for new IRC users.\r\n\t-The ChatZilla website https://github.com/ChatZilla-Replacement-Project provides more information about IRC and Best Chat, including the Best Chat FAQ https://github.com/ChatZilla-Replacement-Project/.github/blob/main/profile/README.md, which  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string strClientEventHelpInfo {
            get {
                return ResourceManager.GetString("strClientEventHelpInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hello.
        /// </summary>
        internal static string strClientEventTypeNameHello {
            get {
                return ResourceManager.GetString("strClientEventTypeNameHello", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Information.
        /// </summary>
        internal static string strClientEventTypeNameInfo {
            get {
                return ResourceManager.GetString("strClientEventTypeNameInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Welcome to Best Chat.\r\nBelow is a short selection of information to help you get started using Best Chat..
        /// </summary>
        internal static string strClientEventWelcomeToBestChat {
            get {
                return ResourceManager.GetString("strClientEventWelcomeToBestChat", resourceCulture);
            }
        }
    }
}