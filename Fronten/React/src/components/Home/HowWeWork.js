import React from 'react';

function HowWeWork() {
  return (
    <div className='container col-xxl-8 px-4 py-5'>
      <div className='row flex-row g-6 py-5'>
        <div className='col-lg-5'>
          <p className='work_title'>How we work</p>
          <p className='work_subtitle'>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsam laboriosam pariatur vitae et quis.</p>
          <a className='work_link'>Get in touch with us</a>
        </div>
        <div className='col-lg-6'>
          <div className='row row-cols-2'>
            <div className='col'>
              <img src='/icons/pointer 1.png' alt="1" />
              <p className='work_points'>Strategy</p>
              <p className='work_subtitle'>Lorem ipsum dolor sit amet consectetur adipisicing elit.</p>
            </div>
            <div className='col'>
              <img src='/icons/pointer 1.png' alt="1" />
              <p className='work_points'>Strategy</p>
              <p className='work_subtitle'>Lorem ipsum dolor sit amet consectetur adipisicing elit.</p>
            </div>
            <div className='col'>
              <img src='/icons/pointer 1.png' alt="1" />
              <p className='work_points'>Strategy</p>
              <p className='work_subtitle'>Lorem ipsum dolor sit amet consectetur adipisicing elit.</p>
            </div>
            <div className='col'>
              <img src='/icons/pointer 1.png' alt="1" />
              <p className='work_points'>Strategy</p>
              <p className='work_subtitle'>Lorem ipsum dolor sit amet consectetur adipisicing elit.</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default HowWeWork;
