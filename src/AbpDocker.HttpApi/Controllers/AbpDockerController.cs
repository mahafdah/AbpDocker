using AbpDocker.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpDocker.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpDockerController : AbpControllerBase
{
    protected AbpDockerController()
    {
        LocalizationResource = typeof(AbpDockerResource);
    }
}
