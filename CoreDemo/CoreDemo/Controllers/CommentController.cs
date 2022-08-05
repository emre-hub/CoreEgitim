﻿using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        /*<div class="comment-top">
                            <h4>Yorumlar</h4>
                            <div class="media">
                                <img src="~/CoreBlogTema/images/t1.jpg" alt="" class="img-fluid" />
                                <div class="media-body">
                                    <h5 class="mt-0">Joseph Goh</h5>
                                    <p>
                                        Lorem Ipsum convallis diam consequat magna vulputate malesuada. id dignissim sapien velit id felis ac cursus eros.
                                        Cras a ornare elit.
                                    </p>

                                    <div class="media mt-3">
                                        <a class="d-flex pr-3" href="#">
                                            <img src="~/CoreBlogTema/images/t2.jpg" alt="" class="img-fluid" />
                                        </a>
                                        <div class="media-body">
                                            <h5 class="mt-0">Richard Spark</h5>
                                            <p>
                                                Lorem Ipsum convallis diam consequat magna vulputate malesuada. id dignissim sapien velit id felis ac cursus eros.
                                                Cras a ornare elit.
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>*/
        public PartialViewResult CommentListByBlog()
        {
            return PartialView();
        }
    }
}
