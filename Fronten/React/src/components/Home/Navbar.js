import React, { useEffect, useState } from 'react'

function Navbar() {
    const [colorBg, setBg] = useState('transparent')
    const [stImg, setSt] = useState('main_st')
    const [schlImg, setSchl] = useState('main_schl')

    const refBg = React.useRef()
    const refSt = React.useRef()
    const refSchl = React.useRef()

    refBg.current = colorBg
    refSt.current = stImg
    refSchl.current = schlImg

    const nav_styles = {
        color: {
            backgroundColor: '#000000',
            padding: '0.8rem',
            transition: '0.4s'
        },
        transparent: {
            padding: '1.5rem',
            transition: '0.4s'
        },
        main_st: {
            width: '120px',
            marginRight: '10px'
        },
        small_st: {
            width: '90px',
            height: '75px',
            marginRight: '10px'
        },

        main_schl: {
            width: '80px',
        },
        small_schl: {
            width: '60px',
            height: '80px',
        }
    }
    useEffect(() => {
        const changeNavbarColor = () => {
            if (window.scrollY >= 100) {
                setBg('color')
                setSt('small_st')
                setSchl('small_schl')
            }
            else {
                setBg('transparent')
                setSt('main_st')
                setSchl('main_schl')
            }
        };
        document.addEventListener('scroll', changeNavbarColor);
        return () => {
            document.removeEventListener('scroll', changeNavbarColor)
        }
    })

    return (
        <div>
            <nav className='fixed-top' style={nav_styles[refBg.current]}>
                <div className='navbar_main'>
                    <div className='navbar_imgs'>
                        <img style={nav_styles[refSt.current]} src='/logos/student_council_logo_white.png' alt='student_council_logo' />
                        <img style={nav_styles[refSchl.current]} src='/logos/school_logo_white.png' alt='school_logo' />
                    </div>
                    <div className='navbar_links'>
                        <a className='nav_link'>Home</a>
                        <a className='nav_link'>Members</a>
                        <a className='nav_link'>Departments</a>
                        <a className='nav_link'>Projects</a>
                        <a className='nav_link'>About us</a>
                    </div>
                </div>
            </nav>
        </div>
    );
}

export default Navbar;
