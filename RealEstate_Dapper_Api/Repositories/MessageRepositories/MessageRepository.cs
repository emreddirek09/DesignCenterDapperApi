using Dapper;
using RealEstate_Dapper_Api.Dtos.MessageDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.MessageRepositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultInBoxMessageDto>> GetInBoxLast3MessagelistByReceiver(int id)
        {   
            string query = $@"select Top(3) MessageId,Name,Subject,Detail,SendDate,IRead,UserImageUrl from Message as M
                                Inner Join AppUser
                                on M.Sender=AppUser.UserId
                                where M.Receiver=@receiverid Order by MessageId Desc";
            var param = new DynamicParameters();
            param.Add("@receiverid", id);

            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryAsync<ResultInBoxMessageDto>(query, param);
                return values.ToList();
            }
        }
    }
}
