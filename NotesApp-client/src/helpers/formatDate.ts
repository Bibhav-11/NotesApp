export default function formatCreatedTime(createdTime) {
    const currentTime = new Date();
    const timeDifference = new Date(createdTime) - currentTime;

    // Convert time difference to seconds
    const seconds = Math.floor(timeDifference / 1000);

    // Define the supported units and their plural forms
    const units = [
        { unit: 'second', value: seconds },
        { unit: 'minute', value: Math.floor(seconds / 60) },
        { unit: 'hour', value: Math.floor(seconds / 3600) },
        { unit: 'day', value: Math.floor(seconds / 86400) }
    ];

    // Find the most appropriate unit
    let unit = units[0];
    for (const u of units) {
        if (Math.abs(u.value) < 2) {
            unit = u;
            break;
        }
    }


    // Initialize Intl.RelativeTimeFormat
    const rtf = new Intl.RelativeTimeFormat('en', { numeric: 'always', style: "long" });

    // Format the time difference
    return rtf.format(unit.value, unit.unit);
}

// Example usage:
