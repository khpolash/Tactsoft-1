using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly ICompanyInfoServices _companyInfoServices;
        private readonly IBranchInfoServices _branchInfoServices;

        public ProjectController(IProjectService projectService, ICompanyInfoServices companyInfoServices, IBranchInfoServices branchInfoServices)
        {
            this._projectService = projectService;
            this._companyInfoServices = companyInfoServices;
            this._branchInfoServices = branchInfoServices;
        }


        // GET: ProjectController
        public async Task<IActionResult> Index()
        {
            var Project = await _projectService.GetAllAsync(e => e.CompanyInfo, e => e.BranchInfo);
            return View(Project);
        }

        // GET: ProjectController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            var Project = await _projectService.FindAsync(x => x.Id == id, x => x.CompanyInfo, x => x.BranchInfo);
            if (Project == null)
            {
                return NotFound();
            }
            return View(Project);
        }

        // GET: ProjectController/Create
        public ActionResult Create()
        {
            ViewData["CompanyInfoId"] = _companyInfoServices.Dropdown();
            ViewData["BranchInfoId"] = _branchInfoServices.Dropdown();
            return View();
        }

        // POST: ProjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    await _projectService.InsertAsync(project);
                    TempData["SuccessAlert"] = "Project Insert Successfull";
                }

                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyInfoId"] = _companyInfoServices.Dropdown();
            ViewData["BranchInfoId"] = _branchInfoServices.Dropdown();
            return View(project);
        }

        // GET: ProjectController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Project = await _projectService.FindAsync(x => x.Id == id, x => x.CompanyInfo, x => x.BranchInfo);
            if (Project == null)
            {
                return NotFound();
            }
            ViewData["CompanyInfoId"] = _companyInfoServices.Dropdown();
            ViewData["BranchInfoId"] = _branchInfoServices.Dropdown();
            return View(Project);
        }

        // POST: ProjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Project project)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var pro = await _projectService.FindAsync(id);
                    pro.ProjectName = project.ProjectName;
                    pro.ProjectDescription = project.ProjectDescription;
                    pro.CompanyInfoId = project.CompanyInfoId;
                    pro.BranchInfoId = project.BranchInfoId;
                    pro.Duraction = project.Duraction;
                    pro.StartDate = project.StartDate;
                    pro.EndDate = project.EndDate;
                    await _projectService.UpdateAsync(pro);
                    TempData["SuccessAlert"] = "Update Successfull";

                }

                catch
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyInfoId"] = _companyInfoServices.Dropdown();
            ViewData["BranchInfoId"] = _branchInfoServices.Dropdown();

            return View(project);
        }

        // GET: ProjectController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var Project = await _projectService.FindAsync(x => x.Id == id, x => x.CompanyInfo, x => x.BranchInfo);
            if (Project == null)
            {
                return NotFound();
            }
            return View(Project);
        }

        // POST: ProjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Project project)
        {
            var pro = await _projectService.FindAsync(x => x.Id == id, x => x.CompanyInfo, x => x.BranchInfo);
            if (pro != null)
            {
                await _projectService.DeleteAsync(project);
                TempData["SuccessAlert"] = "Project Delete Successfull";
            }
            ViewData["CompanyInfoId"] = _companyInfoServices.Dropdown();
            ViewData["BranchInfoId"] = _branchInfoServices.Dropdown();
            TempData["errorAlert"] = "Unable to Delete";
            return View(project);

        }
    }
}
