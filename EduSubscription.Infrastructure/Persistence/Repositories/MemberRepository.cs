﻿using EduSubscription.Core.Members;
using EduSubscription.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduSubscription.Infrastructure.Persistence.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly AppDbContext _appDbContext;

    public MemberRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task Add(Member member)
    {
        await _appDbContext.Members.AddAsync(member);
    }

    public async Task<List<Member>> ReadAll()
    {
        return await _appDbContext.Members.ToListAsync();
    }

    public async Task<Member?> ReadById(Guid id)
    {
        return await _appDbContext.Members.SingleOrDefaultAsync(o => o.Id == id);
    }

    public async Task<bool> Delete(Guid id)
    {
        var member = await ReadById(id);
        if (member is null) return false;
        _appDbContext.Members.Remove(member);
        return true;
    }
}