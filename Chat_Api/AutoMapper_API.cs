using AutoMapper;
using Chat_Api.Models;
using Chat_Business.Models;

namespace Chat_Api
{
    public class AutoMapper_API
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<ChatModelAPI, ChatModelBL>();
                config.CreateMap<ChatModelBL, ChatModelAPI>();

                config.CreateMap<MessageModelAPI, MessageModelBL>();
                config.CreateMap<MessageModelBL, MessageModelAPI>();

                config.CreateMap<UserModelAPI, UserModelBL>();
                config.CreateMap<UserModelBL, UserModelAPI>();
            });
        }
    }
}
