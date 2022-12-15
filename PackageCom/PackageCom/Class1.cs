using System;
using System.Collections.Generic;
namespace PackageCom
{

    public class Common
    {
        private string kind;
        private string content;

        public Common(string kind, string content)
        {
            this.kind = kind;
            this.content = content;
        }

        public string Kind { get => kind; set => kind = value; }
        public string Content { get => content; set => content = value; }
    }

    public class Login
    {
        private string username;
        private string password;

        public Login(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }

    public class Logout
    {
        private string username;

        public Logout(string username)
        {
            this.username = username;
        }

        public string Username { get => username; set => username = value; }
    }

    public class Chat
    {
        private string sender;
        private string receiver;
        private string content;

        public Chat(string sender, string receiver, string content)
        {
            this.sender = sender;
            this.receiver = receiver;
            this.content = content;
        }

        public string Sender { get => sender; set => sender = value; }
        public string Receiver { get => receiver; set => receiver = value; }
        public string Content { get => content; set => content = value; }
    }
    public class Response
    {
        private string content;

        public Response(string content)
        {
            this.content = content;
        }

        public string Content { get => content; set => content = value; }
    }

    public class Group
    {
        private string groupName;
        private string memberName;

        public Group(string groupName, string memberName)
        {
            this.groupName = groupName;
            this.memberName = memberName;
        }

        public string GroupName { get => groupName; set => groupName = value; }
        public string MemberName { get => memberName; set => memberName = value; }
    }
}