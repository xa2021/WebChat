namespace Chat5.Services
{
    public interface ICurrentUserService
    {

        public Guid UserId { get;  }
        public string? UserName { get; }
        public string? UserNickname { get;  }

    }
}
