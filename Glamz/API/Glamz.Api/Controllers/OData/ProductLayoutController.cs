﻿using Glamz.Api.Queries.Models.Common;
using Glamz.Business.Common.Interfaces.Security;
using Glamz.Business.Common.Services.Security;
using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading.Tasks;

namespace Glamz.Api.Controllers.OData
{
    public partial class ProductLayoutController : BaseODataController
    {
        private readonly IMediator _mediator;
        private readonly IPermissionService _permissionService;

        public ProductLayoutController(IMediator mediator, IPermissionService permissionService)
        {
            _mediator = mediator;
            _permissionService = permissionService;
        }

        [SwaggerOperation(summary: "Get entity from ProductLayout by key", OperationId = "GetProductLayoutById")]
        [HttpGet("{key}")]
        public async Task<IActionResult> Get(string key)
        {
            if (!await _permissionService.Authorize(PermissionSystemName.Maintenance))
                return Forbid();

            var layout = await _mediator.Send(new GetLayoutQuery() { Id = key, LayoutName = typeof(Domain.Catalog.ProductLayout).Name });
            if (!layout.Any())
                return NotFound();

            return Ok(layout.FirstOrDefault());

        }

        [SwaggerOperation(summary: "Get entities from ProductTemplate", OperationId = "GetProductTemplates")]
        [HttpGet]
        [EnableQuery(HandleNullPropagation = HandleNullPropagationOption.False)]
        public async Task<IActionResult> Get()
        {
            if (!await _permissionService.Authorize(PermissionSystemName.Maintenance))
                return Forbid();

            return Ok(await _mediator.Send(new GetLayoutQuery() { LayoutName = typeof(Domain.Catalog.ProductLayout).Name }));
        }
    }
}
