import { createFileRoute, Outlet } from '@tanstack/react-router'
import { SidebarInset, SidebarProvider } from '#/components/ui/sidebar.tsx'
import { MainSidebar } from '#/components/sidebar/MainSidebar.tsx'
import { useMemo, useState } from 'react'

export const Route = createFileRoute('/_authenticated/_sidebar')({
  component: RouteComponent,
})

function RouteComponent() {
  const [isOpen, setIsOpen] = useState(false)

  const { auth, user } = Route.useRouteContext()

  const sidebarUser = useMemo(() => {
    const u = user?.user

    if (!u) return null


    return {
      emailAddress: u.emailAddresses[0]?.emailAddress ?? null,
      imageUrl: u.imageUrl,
      fullName: u.fullName,
      username: u.username,
      signOut: () => auth.signOut()
    }
  }, [user])

  return (
    <SidebarProvider open={isOpen}>
      <MainSidebar
        user={sidebarUser}
        onMouseEnter={() => setIsOpen(true)}
        onMouseLeave={() => setIsOpen(false)}
      />
      <SidebarInset>
        <Outlet />
      </SidebarInset>
    </SidebarProvider>
  )
}
