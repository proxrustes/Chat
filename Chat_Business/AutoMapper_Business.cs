using AutoMapper;
using Chat_Business.Models;
using Chat_Database.Models;

namespace Chat_Business
{
    public static class AutoMapper_Business
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<ChatEntity, ChatModelBL>();
                config.CreateMap<ChatModelBL, ChatEntity>();

                config.CreateMap<MessageEntity, MessageModelBL>();
                config.CreateMap<MessageModelBL, MessageEntity>();

                config.CreateMap<UserEntity, UserModelBL>();
                config.CreateMap<UserModelBL, UserEntity>();
            });
        }
    }
}