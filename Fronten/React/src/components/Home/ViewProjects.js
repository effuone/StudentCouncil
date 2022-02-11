import React from 'react';

function ViewProjects() {
  return (
    <div className='container px-4 py-5'>
      <div className='projects_head mb-5'>
        <p className='work_title'>View projects</p>
        <p>View projects <i class="bi bi-arrow-right"></i></p>
      </div>
      <div className='row'>
        <div className='col-lg-8'>
          <img src='/Card.png' alt='img' style={{ width: "100%", height: "100%" }} />
        </div>
        <div className='col-lg-4 d-flex flex-column'>
          <img style={{ marginBottom: '3rem' }} src='/people/students.png' width={380} />
          <img src='/people/students.png' width={380} />
          <img />
        </div>
      </div>
    </div>
  );
}

export default ViewProjects;
