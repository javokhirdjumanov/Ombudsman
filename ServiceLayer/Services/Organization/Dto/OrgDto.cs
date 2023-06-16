﻿using DomainLayer.Entities.ENUM;
using DomainLayer.Entities.INFO;

namespace ServiceLayer.Services;
public class OrgDto
{
    public int id { get; set; }
    public int ordernumber { get; set; }
    public StateOrganization stateorganization{ get; set; }
    public bool is_grouper { get; set; }
    public Organization? supreororganization { get; set; }
    public string? short_name { get; set; }
    public string? full_name { get; set; }
    public State state { get; set; }
}
