﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace KoiCareSystemAtHome.Repositories.Repositories
{
    public class FeedingScheduleRepository : IFeedingScheduleRepository
    {
        private readonly KoiCareSystemAtHomeContext _DbContext;
        public FeedingScheduleRepository(KoiCareSystemAtHomeContext dbcontext)
        {
            _DbContext = dbcontext;
        }

        public bool AddFeedingSchedule(FeedingSchedule feeding)
        {
            try
            {
                _DbContext.FeedingSchedules.Add(feeding);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelFeedingSchedule(int Id)
        {
            try
            {
                var objDel = _DbContext.FeedingSchedules.Where(p => p.FeedingScheduleId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _DbContext.FeedingSchedules.Remove(objDel);
                    _DbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelFeedingSchedule(FeedingSchedule feeding)
        {
            try
            {
                _DbContext.Remove(feeding);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<FeedingSchedule>> GetAllFeedingSchedules()
        {
            return await _DbContext.FeedingSchedules.ToListAsync();
        }

        public async Task<FeedingSchedule?> GetFeedingScheduleById(int? Id)
        {
            return await _DbContext.FeedingSchedules.Where(p => p.FeedingScheduleId.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UpdateFeedingSchedule(FeedingSchedule feeding)
        {
            try
            {
                _DbContext.FeedingSchedules.Update(feeding);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}

