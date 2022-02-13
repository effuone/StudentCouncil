import React from 'react';
import Footer from '../components/Footer';
import AboutDepartments from '../components/Home/AboutDepartments';
import AskedQst from '../components/Home/AskedQst';
import Hero from '../components/Home/Hero'
import HowWeWork from '../components/Home/HowWeWork';
import Navbar from '../components/Home/Navbar';
import News from '../components/Home/News';
import ViewProjects from '../components/Home/ViewProjects';

function Home() {
    return (
        <div>
            <div style={bgStyle} className='px-5 py-4'>
                <div className='container-fluid'>
                    <Navbar />
                    <Hero />
                </div>
            </div>
            <div className='mt-4 px-5 py-4'>
                <AboutDepartments />
            </div>
            <div style={{ backgroundColor: '#F4F6FC' }}>
                <HowWeWork />
            </div>
            <div className='mt-4'>
                <ViewProjects />
            </div>
            <div className='mt-4'>
                <AskedQst />
            </div>
            <div className='mt-4'>
                <News />
            </div>
            <Footer/>
        </div>
    );
}

const bgStyle = {
    backgroundImage: "url(/bg_home.png)",
    backgroundRepeat: 'no-repeat',
    backgroundPosition: 'center',
    backgroundSize: 'cover',
}

export default Home;
