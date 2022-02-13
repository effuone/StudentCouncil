import React from 'react'

function News() {
    return (
        <div className='container px-4 py-5'>
            <div className='news_content'>
                <p className='work_title'>News</p>
                <div className='row' style={{ marginTop: '3rem' }}>
                    <div className='col-md-4 mb-3'>
                        <img style={{ width: '100%' }} src='/people/students.png' />
                        <p className='work_subtitle'>19 Jan 2022</p>
                        <p className='news_title'>Об Объединении <span style={{ fontWeight: '500' }}>"Alumni Nazarbayev Intellectual Schools"</span></p>
                        <p className='news_des'>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis, veniam corporis iste reprehenderit dignissimos reiciendis exercitationem.</p>
                    </div>
                    <div className='col-md-4 mb-3'>
                        <img style={{ width: '100%' }} src='/people/students.png' />
                        <p className='work_subtitle'>19 Jan 2022</p>
                        <p className='news_title'>Об Объединении <span style={{ fontWeight: '500' }}>"Alumni Nazarbayev Intellectual Schools"</span></p>
                        <p className='news_des'>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis, veniam corporis iste reprehenderit dignissimos reiciendis exercitationem.</p>
                    </div>
                    <div className='col-md-4'>
                        <img style={{ width: '100%' }} src='/people/students.png' />
                        <p className='work_subtitle'>19 Jan 2022</p>
                        <p className='news_title'>Об Объединении <span style={{ fontWeight: '500' }}>"Alumni Nazarbayev Intellectual Schools"</span></p>
                        <p className='news_des'>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis, veniam corporis iste reprehenderit dignissimos reiciendis exercitationem.</p>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default News