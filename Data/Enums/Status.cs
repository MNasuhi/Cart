using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Enums
{
    public enum Status : int
    {
        Created = 1,
        Updated = 2,
        Deleted = 3
    }

    public class StatusEnumConvert
    {
        public int Id { get; set; }
        public Status StatusName { get; set; }

        public Status GetEnumById (int Id)
        {

            List<StatusEnumConvert> statuses = new List<StatusEnumConvert>
            {
                new StatusEnumConvert { Id = 1 ,  StatusName = Status.Created},
                new StatusEnumConvert { Id = 2 ,  StatusName = Status.Updated},
                new StatusEnumConvert { Id = 3 ,  StatusName = Status.Deleted},
            };

            return statuses.Where(x => x.Id == Id).SingleOrDefault().StatusName;
        }


        public int GetIdByEnum(Status status)
        {

            List<StatusEnumConvert> statuses = new List<StatusEnumConvert>
            {
                new StatusEnumConvert { Id = 1 ,  StatusName = Status.Created},
                new StatusEnumConvert { Id = 2 ,  StatusName = Status.Updated},
                new StatusEnumConvert { Id = 3 ,  StatusName = Status.Deleted},
            };

            return statuses.Where(x => x.StatusName == status).SingleOrDefault().Id;
        }
    }
}
