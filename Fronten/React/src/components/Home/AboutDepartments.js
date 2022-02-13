import React from 'react';

function AboutDepartments() {
  return (
    <div class="container col-xxl-8 px-4 py-5">
      <div class="row flex-lg-row-reverse align-items-center g-5 py-5">
        <div class="col-lg-6">
          <img src='/people/students.png' class="d-block mx-lg-auto img-fluid" alt="students" width="700" height="500" loading="lazy" />
        </div>
        <div class="col-lg-6">
          <p className='dep_subtitle'>About us</p>
          <h3 className='dep_title'>Our departments <br />solve problems </h3>
          <p className='dep_des'>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Nihil iusto repellendus, libero soluta sapiente dolore deserunt aliquid, architecto vero dicta eaque? Saepe veniam minus non corrupti unde, quas ipsa quibusdam.</p>
        </div>
      </div>
    </div>
  );
}

export default AboutDepartments;
