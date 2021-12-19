import { useEffect } from 'react';

function SetPageTitle(title) {
    useEffect(() => {
        document.title = title;
    }, [title]);
}

export default SetPageTitle;