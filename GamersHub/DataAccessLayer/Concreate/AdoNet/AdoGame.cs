using DataAccessLayer.Abstract;
using DataAccessLayer.DBContext;
using Entity.POCO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concreate.AdoNet
{
    public class AdoGame : IGameDAL
    {
        private readonly GamersHubContext dbContext = new GamersHubContext();
        SqlConnection sqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=GamersHubDB;Trusted_Connection=True;");
        SqlCommand command = new SqlCommand();
        public bool Add(Game entity)
        {
            using (sqlConnection)
            {

                sqlConnection.Open();
                using (command)
                {
                    command.Connection = sqlConnection;

                    command.CommandText = $"insert into {nameof(dbContext.Games)} ({nameof(Game.Active)},{nameof(Game.Deleted)},{nameof(Game.CreatedTime)},{nameof(Game.UpdatedTime)},Name,{nameof(Game.Price)},{nameof(Game.Version)},{nameof(Game.Description)},{nameof(Game.CreatorName)},{nameof(Game.Rating)},{nameof(Game.Size)}) values ('{entity.Active}','{entity.Deleted}','{entity.CreatedTime}','{entity.UpdatedTime}','{entity.GameName}',{entity.Price},'{entity.Version}','{entity.Description}','{entity.CreatorName}',{entity.Rating},{entity.Size})";

                    int result = command.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }



        }

        public bool Delete(Game entity)
        {
            using (sqlConnection)
            {
                sqlConnection.Open();
                using (command)
                {
                    command.Connection = sqlConnection;
                    command.CommandText = $"update {nameof(dbContext.Games)} set {nameof(Game.Active)}='{false}',{nameof(Game.Deleted)}='{true}',{nameof(Game.CreatedTime)}='{entity.CreatedTime}',{nameof(Game.UpdatedTime)}='{entity.UpdatedTime}',Name='{entity.GameName}',{nameof(Game.Price)}={entity.Price},{nameof(Game.Version)}='{entity.Version}',{nameof(Game.Description)}='{entity.Description}',{nameof(Game.CreatorName)}='{entity.CreatorName}',{nameof(Game.Rating)}={entity.Rating},{nameof(Game.Size)}={entity.Size} where {nameof(Game.Id)} = {entity.Id}";
                    //command.CommandText = $"Delete from {nameof(dbContext.Games)} where {nameof(Game.Id)} = {entity.Id}";

                    int result = command.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

        }

        public Game Get(int id)
        {
            using (sqlConnection)
            {
                sqlConnection.Open();
                using (command)
                {
                    command.Connection = sqlConnection;

                    command.CommandText = $"select * from {nameof(dbContext.Games)} where {nameof(Game.Id)} = {id}";

                    var result = command.ExecuteReader();
                    Game game = null;


                    if (result.Read())
                    {

                        game = new Game { Id = result.GetInt32(0), Active = result.GetBoolean(1), Deleted = result.GetBoolean(2), CreatedTime = result.GetDateTime(3), UpdatedTime = result.GetDateTime(4), GameName = result.GetString(5), Description = result.GetString(6), Price = result.GetDouble(7), Version = result.GetString(8), CreatorName = result.GetString(9), Rating = result.GetDouble(10), Size = result.GetDouble(11) };
                        sqlConnection.Close();

                    }
                    else
                    {
                        sqlConnection.Close();
                        return null;
                    }
                    return game;
                }
            }

        }

        public IEnumerable<Game> Get()
        {
            using (sqlConnection)
            {
                sqlConnection.Open();
                using (command)
                {
                    command.Connection = sqlConnection;

                    command.CommandText = $"select * from {nameof(dbContext.Games)}";

                    var result = command.ExecuteReader();
                    while (result.Read())
                    {

                        yield return new Game { Id = result.GetInt32(0), Active = result.GetBoolean(1), Deleted = result.GetBoolean(2), CreatedTime = result.GetDateTime(3), UpdatedTime = result.GetDateTime(4), GameName = result.GetString(5), Description = result.GetString(6), Price = result.GetDouble(7), Version = result.GetString(8), CreatorName = result.GetString(9), Rating = result.GetDouble(10), Size = result.GetDouble(11) };
                    }
                    sqlConnection.Close();
                }
            }
        }

        public bool Update(Game entity)
        {
            using (sqlConnection)
            {
                sqlConnection.Open();

                using (command)
                {
                    command.Connection = sqlConnection;

                    command.CommandText = $"update {nameof(dbContext.Games)} set {nameof(Game.Active)}='{entity.Active}',{nameof(Game.Deleted)}='{entity.Deleted}',{nameof(Game.CreatedTime)}='{entity.CreatedTime}',{nameof(Game.UpdatedTime)}='{entity.UpdatedTime}',Name='{entity.GameName}',{nameof(Game.Price)}={entity.Price},{nameof(Game.Version)}='{entity.Version}',{nameof(Game.Description)}='{entity.Description}',{nameof(Game.CreatorName)}='{entity.CreatorName}',{nameof(Game.Rating)}={entity.Rating},{nameof(Game.Size)}={entity.Size} where {nameof(Game.Id)} = {entity.Id}";

                    int result = command.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
        }
    }
}
