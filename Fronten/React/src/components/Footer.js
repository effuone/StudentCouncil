import React from 'react'

function Footer() {
    return (
        <div className='footer_bg'>
            <div className='container px-4 py-5'>
                <div className='row g-8'>
                    <div className='col-md-4'>
                        <p className='footer_title'>Student Council</p>
                        <p className='footer_des'>We are always open to discuss your project and improve your online presence.</p>
                    </div>
                    <div className='col-md-4'>
                        <p className='footer_title'>Let's talk</p>
                        <p className='footer_des'>We are always open to discuss your project, improve your online presence and help with your ideas!</p>
                        <div className='media_links'>
                            <i className="bi bi-facebook"></i>
                            <i className="bi bi-twitter"></i>
                            <i className="bi bi-instagram"></i>
                            <i className="bi bi-youtube"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Footer