import React from 'react';

const Hero = ({ style }) => {


    return (
        <div className='col-xxl-8' style={{ marginTop: '8rem' }} >
            <div className="row align-items-center g-5 py-5">
                <div className="col-lg-5">
                    <p className="mb-3 home_title">Student Council</p>
                    <p className="lead text-white">We focus on the development of school life, events, innovations, education and build a better future for our school! </p>
                    <div className="d-grid gap-2 d-md-flex justify-content-md-start mt-5">
                        <button type="button" className="btn btn-warning btn-lg px-4 me-md-2">Learn more</button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Hero;
