const API_URL = '/api/jobs';

// Load jobs on page load
document.addEventListener('DOMContentLoaded', fetchJobs);

// Handle form submission
document.getElementById('addJobForm').addEventListener('submit', async (e) => {
    e.preventDefault();

    const newJob = {
        companyName: document.getElementById('companyName').value,
        positionTitle: document.getElementById('positionTitle').value,
        location: document.getElementById('location').value,
        jobUrl: document.getElementById('jobUrl').value,
        salaryRange: document.getElementById('salaryRange').value,
        status: document.getElementById('status').value,
        dateApplied: new Date().toISOString()
    };

    try {
        const response = await fetch(API_URL, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(newJob)
        });

        if (response.ok) {
            document.getElementById('addJobForm').reset();
            fetchJobs(); // Refresh the list
        } else {
            alert('Failed to add job. Check the console for errors.');
        }
    } catch (error) {
        console.error('Error adding job:', error);
    }
});

async function fetchJobs() {
    try {
        const response = await fetch(API_URL);
        const jobs = await response.json();
        displayJobs(jobs);
    } catch (error) {
        console.error('Error fetching jobs:', error);
    }
}

function displayJobs(jobs) {
    const tbody = document.getElementById('jobsBody');
    tbody.innerHTML = '';

    jobs.forEach(job => {
        const date = new Date(job.dateApplied).toLocaleDateString();
        const tr = document.createElement('tr');
        
        // Strip out whitespace for the CSS status class name
        const statusClass = `status-${job.status.replace(/\\s+/g, '')}`;
        
        tr.innerHTML = `
            <td>
                <strong>${job.companyName}</strong>
                ${job.jobUrl ? `<br><a href="${job.jobUrl}" target="_blank" style="color: #94a3b8; font-size: 0.8rem; text-decoration: none;">View Link →</a>` : ''}
            </td>
            <td>${job.positionTitle}</td>
            <td><span class="status-badge ${statusClass}">${job.status}</span></td>
            <td>${date}</td>
            <td>
                <button class="btn-delete" onclick="deleteJob(${job.id})">Delete</button>
            </td>
        `;
        tbody.appendChild(tr);
    });
}

async function deleteJob(id) {
    if (!confirm('Are you sure you want to delete this application?')) return;

    try {
        const response = await fetch(`${API_URL}/${id}`, {
            method: 'DELETE'
        });

        if (response.ok) {
            fetchJobs(); // Refresh the list
        }
    } catch (error) {
        console.error('Error deleting job:', error);
    }
}
